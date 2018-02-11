
using GTA;
using GTA.Native;

/*
    Color syntax:
    ~r~ = Red
    ~b~ = Blue
    ~g~ = Green
    ~y~ = Yellow
    ~p~ = Purple
    ~o~ = Orange
    ~c~ = Grey
    ~m~ = Dark Grey
    ~u~ = Black
    ~s~ = Default White
    ~d~ = Dark blue
    ~f~ = Light blue
    ~l~ = Black
    ~t~ = Gray
    ~v~ = Black

    ~n~ = New Line
    ~h~ = Bold Text
    ~nrt~ = CRLF
    ~italic~ = italic
    ~bold~ = bold
    ~r~<font size="150"> = font size 150 (full screen)

    Special characters:
    ¦ = Rockstar Verified Icon (U+00A6:Broken Bar - Alt+0166)
    ÷ = Rockstar Icon (U+00F7:Division Sign - Alt+0247)
    ∑ = Rockstar Icon 2 (U+2211:N-Ary Summation)
    Ω = Lock icon
    ~ws~ = Wanted Star
*/

namespace SE
{
    class Camera
    {
        /// <summary>
        /// Fade the screen (fade out + fade in).
        /// </summary>
        /// <param name="fadeOutDuration"></param>
        /// <param name="fadeInDuration"></param>
        public static void Fade(int fadeOutDuration, int fadeInDuration = 0)
        {
            if (fadeInDuration == 0)
                fadeInDuration = fadeOutDuration;
            Game.FadeScreenOut(fadeOutDuration);
            GTA.Script.Wait(fadeOutDuration + 500);
            Game.FadeScreenIn(fadeOutDuration);
        }

        /// <summary>
        /// Start a screen effect.
        /// </summary>
        /// <param name="effect"></param>
        public static void StartScreenEffect(ScreenEffect effect)
        {
            Function.Call(Hash._START_SCREEN_EFFECT, effect.ToString(), 0, true);
        }

        /// <summary>
        /// Stop a screen effect.
        /// </summary>
        /// <param name="effect"></param>
        public static void StopScreenEffect(ScreenEffect effect)
        {
            Function.Call(Hash._STOP_SCREEN_EFFECT, effect.ToString());
        }

        /// <summary>
        /// Stop all screen effects.
        /// </summary>
        public static void StopAllScreenEffect()
        {
            Function.Call(Hash._STOP_ALL_SCREEN_EFFECTS);
        }
    }

    /// <summary>
    /// Use the name of the enum.
    /// ie: SwitchHudIn.ToString()
    /// </summary>
    public enum ScreenEffect
    {
        SwitchHudIn,
        SwitchHudOut,
        FocusIn,
        FocusOut,
        MinigameEndNeutral,
        MinigameEndTrevor,
        MinigameEndFranklin,
        MinigameEndMichael,
        MinigameTransitionOut,
        MinigameTransitionIn,
        SwitchShortNeutralIn,
        SwitchShortFranklinIn,
        SwitchShortTrevorIn,
        SwitchShortMichaelIn,
        SwitchOpenMichaelIn,
        SwitchOpenFranklinIn,
        SwitchOpenTrevorIn,
        SwitchHudMichaelOut,
        SwitchHudFranklinOut,
        SwitchHudTrevorOut,
        SwitchShortFranklinMid,
        SwitchShortMichaelMid,
        SwitchShortTrevorMid,
        DeathFailOut,
        CamPushInNeutral,
        CamPushInFranklin,
        CamPushInMichael,
        CamPushInTrevor,
        SwitchSceneFranklin,
        SwitchSceneTrevor,
        SwitchSceneMichael,
        SwitchSceneNeutral,
        MpCelebWin,
        MpCelebWinOut,
        MpCelebLose,
        MpCelebLoseOut,
        DeathFailNeutralIn,
        DeathFailMpDark,
        DeathFailMpIn,
        MpCelebPreloadFade,
        PeyoteEndOut,
        PeyoteEndIn,
        PeyoteIn,
        PeyoteOut,
        MpRaceCrash,
        SuccessFranklin,
        SuccessTrevor,
        SuccessMichael,
        DrugsMichaelAliensFightIn,
        DrugsMichaelAliensFight,
        DrugsMichaelAliensFightOut,
        DrugsTrevorClownsFightIn,
        DrugsTrevorClownsFight,
        DrugsTrevorClownsFightOut,
        HeistCelebPass,
        HeistCelebPassBw,
        HeistCelebEnd,
        HeistCelebToast,
        MenuMgHeistIn,
        MenuMgTournamentIn,
        MenuMgSelectionIn,
        ChopVision,
        DmtFlightIntro,
        DmtFlight,
        DrugsDrivingIn,
        DrugsDrivingOut,
        SwitchOpenNeutralFib5,
        HeistLocate,
        MpJobLoad,
        RaceTurbo,
        MpIntroLogo,
        HeistTripSkipFade,
        MenuMgHeistOut,
        MpCoronaSwitch,
        MenuMgSelectionTint,
        SuccessNeutral,
        ExplosionJosh3,
        SniperOverlay,
        RampageOut,
        Rampage,
        DontTazemeBro,
    }
}
