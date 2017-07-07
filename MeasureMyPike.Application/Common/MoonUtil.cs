using System;

namespace MeasureMyPike.Application.Common
{
    public class MoonUtil
    {
        private static Double LUNAR_CYCLE = 29.530588853;
        private static Double PHASE_LENGTH = LUNAR_CYCLE / 8;
        private static DateTime KNOWN_NEW_MOON = new DateTime(2000, 1, 6);
        private static string[] PHASES = new string[] { "Nymåne", "Tilltagande skära", "Halvmåne" , "Tilltagande halvmåne", "Fullmåne", "Avtagande halvmåne", "Halvmåne", "Avtagande skära"};

        public static int DateToPhase(DateTime date)
        {
            Double days = (date - KNOWN_NEW_MOON).Days;
            days = (days + PHASE_LENGTH/2) % LUNAR_CYCLE;
            int phase = Convert.ToInt32(Math.Round(days * (8 / LUNAR_CYCLE)));

            return phase;
        }

        public static string Phase(DateTime date)
        {
            int phase = DateToPhase(date);

            if (phase >= 0 && phase <= 7)
                return PHASES[phase];
            else
                return "Fel! Okänd månfas " + phase;
        }
    }
}
