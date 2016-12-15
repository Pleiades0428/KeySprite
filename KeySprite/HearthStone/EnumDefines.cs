using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace KeySprite.HearthStone
{
    enum HearthStoneState
    {
        ChooseChar,

        WaitForMatch,

        ChooseCards,

        OponentTurn,

        MyTurn,

        Unknown,

        WaitForContinue,
        GameOverSign
    }

    class GamePosition
    {
        public static Point CHOOSE_CHAR_BEGIN_BUTTON = new Point(962, 625);

        public static Point WAIT_MATCH_LEFT_UP_CORNER = new Point(260, 163);
        public static Point WAIT_MATCH_RIGHT_DOWN_CORNER = new Point(1022, 660);

        public static Point CHOOSE_CARD_HEADER = new Point(543, 115);
        public static Point CHOOSE_CARD_CONFIRM_BUTTON = new Point(692, 633);

        public static Point END_TURN_BUTTON = new Point(1083, 350);

        public static Point MY_CARDS_BEGIN = new Point(300, 770);
        public static Point MY_CARDS_END = new Point(900, 770);

        public static Point PLAY_CARD_TARGET = new Point(639, 440);

        public static Point MY_MINION_BEGIN = new Point(250, 400);
        public static Point MY_MINION_END = new Point(1000, 400);

        public static Point OP_HERO = new Point(643, 161);

        public static Point OP_MINION_BOTTOM_BEGIN = new Point(300, 364);
        public static Point OP_MINION_BOTTOM_END = new Point(900, 364);
        public static int OP_MINION_HEAD_Y = 254;
        public static int OP_MINION_HEAD_HALF_DX = 43;

        public static Point MY_SKILL = new Point(772, 611);
        public static Point MY_HERO = new Point(600, 611);

        public static Point CLICK_TO_CONTINUE_0 = new Point(590, 751);
        public static Point CLICK_TO_CONTINUE_1 = new Point(624, 750);
        public static Point CLICK_TO_CONTINUE_2 = new Point(657, 758);

        public static Point GAME_OVER_SIGN = new Point(639, 571);
    }

    class GameColor
    {
        public static Color CHOOSE_CHAR_BEGIN_BUTTON = Color.FromArgb(204, 255, 255);

        public static Color WAIT_MATCH_LEFT_UP_CORNER = Color.FromArgb(46, 40, 45);
        public static Color WAIT_MATCH_RIGHT_DOWN_CORNER = Color.FromArgb(37, 35, 30);

        public static Color CHOOSE_CARD_HEADER = Color.FromArgb(186, 139, 74);
        public static Color CHOOSE_CARD_CONFIRM_BUTTON = Color.FromArgb(165, 226, 255);

        public static Color MY_TURN_BUTTON_1 = Color.FromArgb(255, 255, 14);
        public static Color MY_TURN_BUTTON_0 = Color.FromArgb(149, 139, 0);

        public static Color OP_TURN_BUTTON_1 = Color.FromArgb(103, 108, 99);
        public static Color OP_TURN_BUTTON_0 = Color.FromArgb(61, 59, 74);

        public static Color HIGHLIGHT_GREEN = Color.FromArgb(88, 255, 58);//todo:

        public static Color BG_COLOR_1 = Color.FromArgb(240, 202, 133);//todo:
        public static Color BG_COLOR_0 = Color.FromArgb(200, 170, 100);//todo:

        public static Color TAUNT_LEFT_UP_COLOR_1 = Color.FromArgb(85, 85, 85);//todo:
        public static Color TAUNT_LEFT_UP_COLOR_0 = Color.FromArgb(65, 65, 65);//todo:


        public static Color TAUNT_RIGHT_UP_COLOR_1 = Color.FromArgb(140, 140, 140);//todo:
        public static Color TAUNT_RIGHT_UP_COLOR_0 = Color.FromArgb(125, 125, 125);//todo:

        public static Color CLICK_TO_CONTINUE_0 = Color.FromArgb(183, 183, 183);
        public static Color CLICK_TO_CONTINUE_1 = Color.FromArgb(251, 251, 251);
        public static Color CLICK_TO_CONTINUE_2 = Color.FromArgb(255, 255, 255);

        public static Color GAME_OVER_SIGN = Color.FromArgb(80, 91, 171);
    }

    enum Guild
    {
        ZS,

        QS,

        MS,

        FS,

        LR,

        SS,

        DLY,

        DZ
    }
}
