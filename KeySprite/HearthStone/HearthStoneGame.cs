using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KeySprite.HearthStone
{
    class HearthStoneGame
    {
        HearthStoneState state;
        Guild guild;
        Task gameTask;
        Logger logger;
        CancellationTokenSource tokenSource = new CancellationTokenSource();
        public bool Running
        {
            get
            {
                return this.gameTask.Status == TaskStatus.Running;
            }
        }

        public HearthStoneGame(Logger logger, Guild guild)
        {
            state = HearthStone.HearthStoneState.Unknown;
            this.logger = logger;
            this.guild = guild;
            gameTask = new Task(() =>
            {
                try
                {
                    while (!tokenSource.IsCancellationRequested)
                    {
                        Thread.Sleep(1000);
                        state = JudgeState();
                        logger.Log(state.ToString());
                        if (state == HearthStoneState.ChooseChar)
                        {
                            Thread.Sleep(500);
                            KeyService.Instance.Click(GamePosition.CHOOSE_CHAR_BEGIN_BUTTON);
                        }
                        else if (state == HearthStoneState.WaitForMatch)
                        {
                            //just wait
                        }
                        else if (state == HearthStoneState.ChooseCards)
                        {
                            Thread.Sleep(500);
                            KeyService.Instance.Click(GamePosition.CHOOSE_CARD_CONFIRM_BUTTON);
                        }
                        else if (state == HearthStoneState.MyTurn)
                        {
                            PlayMyTurn();
                        }
                        else if (state == HearthStoneState.OponentTurn)
                        {
                            //just wait
                        }
                        else if (state == HearthStoneState.WaitForContinue)
                        {
                            KeyService.Instance.Click(GamePosition.MY_HERO);
                        }
                        else if (state == HearthStoneState.GameOverSign)
                        {
                            KeyService.Instance.Click(GamePosition.MY_HERO);
                        }
                        else
                        {
                            //do nothing
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }, tokenSource.Token);
        }

        public HearthStoneState GetState()
        {
            return state;
        }

        public void Start()
        {
            gameTask.Start();
        }

        public void Stop()
        {
            tokenSource.Cancel();
        }

        #region StateJudgement
        private HearthStoneState JudgeState()
        {
            HearthStoneState newState = HearthStoneState.Unknown;
            if (IsChooseChar())
            {
                newState = HearthStoneState.ChooseChar;
            }
            else if (IsWaitingForMatch())
            {
                newState = HearthStoneState.WaitForMatch;
            }
            else if (IsChooseCards())
            {
                newState = HearthStoneState.ChooseCards;
            }
            else if (IsMyTurn())
            {
                newState = HearthStoneState.MyTurn;
            }
            else if (IsOpTurn())
            {
                newState = HearthStoneState.OponentTurn;
            }
            else if (IsWaitContinue())
            {
                newState = HearthStoneState.WaitForContinue;
            }
            else if (IsGameOverSign())
            {
                newState = HearthStoneState.GameOverSign;
            }
            return newState;
        }

        private bool IsChooseChar()
        {
            ScreenMatcher matcher = new ScreenMatcher();
            matcher.AddMatcher(GamePosition.CHOOSE_CHAR_BEGIN_BUTTON, GameColor.CHOOSE_CHAR_BEGIN_BUTTON);
            return matcher.IsMatch();
        }

        private bool IsWaitingForMatch()
        {
            ScreenMatcher matcher = new ScreenMatcher();
            matcher.AddMatcher(GamePosition.WAIT_MATCH_LEFT_UP_CORNER, GameColor.WAIT_MATCH_LEFT_UP_CORNER);
            matcher.AddMatcher(GamePosition.WAIT_MATCH_RIGHT_DOWN_CORNER, GameColor.WAIT_MATCH_RIGHT_DOWN_CORNER);
            return matcher.IsMatch();
        }

        private bool IsChooseCards()
        {
            ScreenMatcher matcher = new ScreenMatcher();
            matcher.AddMatcher(GamePosition.CHOOSE_CARD_HEADER, GameColor.CHOOSE_CARD_HEADER);
            matcher.AddMatcher(GamePosition.CHOOSE_CARD_CONFIRM_BUTTON, GameColor.CHOOSE_CARD_CONFIRM_BUTTON);
            return matcher.IsMatch();
        }

        private bool IsMyTurn()
        {
            ScreenMatcher matcher = new ScreenMatcher();
            matcher.AddMatcher(GamePosition.END_TURN_BUTTON, GameColor.MY_TURN_BUTTON_0, GameColor.MY_TURN_BUTTON_1);
            return matcher.IsMatch();
        }

        private bool IsOpTurn()
        {
            ScreenMatcher matcher = new ScreenMatcher();
            matcher.AddMatcher(GamePosition.END_TURN_BUTTON, GameColor.OP_TURN_BUTTON_0, GameColor.OP_TURN_BUTTON_1);
            return matcher.IsMatch();
        }

        private bool IsWaitContinue()
        {
            ScreenMatcher matcher = new ScreenMatcher();
            matcher.AddMatcher(GamePosition.CLICK_TO_CONTINUE_0, GameColor.CLICK_TO_CONTINUE_0);
            matcher.AddMatcher(GamePosition.CLICK_TO_CONTINUE_1, GameColor.CLICK_TO_CONTINUE_1);
            matcher.AddMatcher(GamePosition.CLICK_TO_CONTINUE_2, GameColor.CLICK_TO_CONTINUE_2);
            return matcher.IsMatch();
        }

        private bool IsGameOverSign()
        {
            ScreenMatcher matcher = new ScreenMatcher();
            matcher.AddMatcher(GamePosition.GAME_OVER_SIGN, GameColor.GAME_OVER_SIGN);
            return matcher.IsMatch();
        }
        #endregion

        #region MyTurn
        private void PlayMyTurn()
        {
            //1.play cards
            Point? pt = FindOnePlayableCard();
            while (pt != null)
            {
                Thread.Sleep(500);
                PlayCard(pt.Value);
                Thread.Sleep(1000);
                pt = FindOnePlayableCard();
            }
            //2.attack
            Thread.Sleep(2000);
            TryAttack();
            Thread.Sleep(2000);
            TryAttack();

            Thread.Sleep(1000);
            CastHeroSkill();
            Thread.Sleep(1000);
            EndTurn();
        }

        private void TryAttack()
        {
            Point? pt = FindOneAttackableMinion();
            while (pt != null)
            {
                Thread.Sleep(2000);
                Point? taunt = FindOneOpTauntMinionNew();
                if (taunt == null)
                {
                    AttackHero(pt.Value);
                }
                else
                {
                    AttackMinion(pt.Value, taunt.Value);
                }
                Thread.Sleep(500);
                KeyService.Instance.MouseMove(GamePosition.MY_HERO);
                Thread.Sleep(2000);

                pt = FindOneAttackableMinion();
            }
        }

        private void EndTurn()
        {
            KeyService.Instance.Click(GamePosition.END_TURN_BUTTON);
        }

        private void AttackHero(Point pt)
        {
            KeyService.Instance.Click(new Point(pt.X + 10, pt.Y + 10));
            Thread.Sleep(500);
            KeyService.Instance.Click(GamePosition.OP_HERO);
            Thread.Sleep(500);
            KeyService.Instance.RightClick();
        }

        private void AttackMinion(Point pt, Point taunt)
        {
            KeyService.Instance.Click(new Point(pt.X + 10, pt.Y + 10));
            Thread.Sleep(500);
            KeyService.Instance.Click(new Point(taunt.X + 10, taunt.Y - 10));
            Thread.Sleep(500);
            KeyService.Instance.RightClick();
        }

        public Point? FindOneOpTauntMinionNew()
        {
            Bitmap bitmap = ScreenService.GetLineFromScreen(GamePosition.OP_MINION_BOTTOM_BEGIN, GamePosition.OP_MINION_BOTTOM_END);
            List<int> list = new List<int>(bitmap.Width);
            for (int i = 0; i < bitmap.Width; i++)
            {
                Color c = bitmap.GetPixel(i, 0);
                list.Add((int)(c.GetBrightness() * 100));
            }
            //string line = string.Join(", ", list.ToArray());
            //logger.Log(line);
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i] - list[i + 1] > 10)
                {
                    //todo
                    Color c = bitmap.GetPixel(i + 3, 0);
                    if (c.G / (c.R + 1) >= 1.5 && c.G / (c.B + 1) >= 1.5)
                    {
                        continue;
                    }

                    return new Point(GamePosition.OP_MINION_BOTTOM_BEGIN.X + i, GamePosition.OP_MINION_BOTTOM_BEGIN.Y);
                }
            }

            return null;
        }

        private Point? FindOneOpTauntMinion()
        {
            Bitmap bitmap = ScreenService.GetLineFromScreen(GamePosition.OP_MINION_BOTTOM_BEGIN, GamePosition.OP_MINION_BOTTOM_END);
            for (int i = 0; i < bitmap.Width; i++)
            {
                Color c = bitmap.GetPixel(i, 0);
                if (IsBGColor(c))
                {
                }
                else
                {
                    Color leftUp = ScreenService.GetColorFromPoint(new Point(GamePosition.OP_MINION_BOTTOM_BEGIN.X + i - GamePosition.OP_MINION_HEAD_HALF_DX, GamePosition.OP_MINION_HEAD_Y));
                    if (IsBGColor(leftUp))
                    {
                        return null;
                    }
                    Color rightUp = ScreenService.GetColorFromPoint(new Point(GamePosition.OP_MINION_BOTTOM_BEGIN.X + i + GamePosition.OP_MINION_HEAD_HALF_DX, GamePosition.OP_MINION_HEAD_Y));
                    if (IsBGColor(rightUp))
                    {
                        return null;
                    }
                    return new Point(GamePosition.OP_MINION_BOTTOM_BEGIN.X + i, GamePosition.OP_MINION_BOTTOM_BEGIN.Y);
                }
            }
            return null;
        }

        private static bool IsBGColor(Color c)
        {
            //todo:
            return c.R >= 200 && c.R <= 240 &&
                                c.G >= 170 && c.G <= 200 &&
                                c.B >= 100 && c.B >= 130;
        }

        private Point? FindOneAttackableMinion()
        {
            return FindOneHighlightCard(GamePosition.MY_MINION_BEGIN, GamePosition.MY_MINION_END);
        }

        private void PlayCard(Point pt)
        {
            //todo: magic cards

            //minion cards
            KeyService.Instance.Click(new Point(pt.X + 10, pt.Y));
            Thread.Sleep(500);
            KeyService.Instance.MouseMove(GamePosition.MY_HERO);
            Thread.Sleep(800);
            KeyService.Instance.Click(GamePosition.OP_HERO);
            Thread.Sleep(500);
            //KeyService.Instance.MouseMove(GamePosition.MY_HERO);
            KeyService.Instance.RightClick();
        }

        private Point? FindOnePlayableCard()
        {
            return FindOneHighlightCard(GamePosition.MY_CARDS_BEGIN, GamePosition.MY_CARDS_END);
        }

        private Point? FindOneHighlightCard(Point begin, Point end)
        {
            Point pt = new Point(0, 0);
            pt.Y = GamePosition.MY_CARDS_BEGIN.Y;

            ScreenMatcher matcher = new ScreenMatcher(80);
            return matcher.GetFirstMatchFromScreen(begin, end, GameColor.HIGHLIGHT_GREEN);
        }

        private void CastHeroSkill()
        {
            if (this.guild == Guild.FS)
            {
                KeyService.Instance.Click(GamePosition.MY_SKILL);
                Thread.Sleep(500);
                KeyService.Instance.Click(GamePosition.OP_HERO);
            }
            else if (this.guild == Guild.MS)
            {
                KeyService.Instance.Click(GamePosition.MY_SKILL);
                Thread.Sleep(500);
                KeyService.Instance.Click(GamePosition.MY_HERO);
            }
            else
            {
                KeyService.Instance.Click(GamePosition.MY_SKILL);
            }
            Thread.Sleep(500);
            KeyService.Instance.RightClick();
        }
        #endregion
    }
}
