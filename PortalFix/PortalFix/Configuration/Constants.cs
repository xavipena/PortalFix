using System;
using System.Collections.Generic;
using System.Text;

namespace PortalFix
{
    public class Constants
    {
        // General
        public const string YES = "Y";
        public const string NO = "N";

        public const string SAY_YES = "Sí";
        public const string SAY_NO = "No";
        public const string SAY_OK = "OK";

        // Various
        public const char Blank = ' ';
        public const char Period = '.';
        public const char Comma = ',';

        public const string Space = " ";
        public const string _Comma = ",";
        public const string Prompt = " :-> ";
        public const string Separator = "  ";
        public const string Slash = "/";
        public const string SingleQuote = "'";
        public const string Percent = "%";
        public const string Star = "*";
        public const string NOD = "#N/D";
        public const string INVALID_KEY = "*Err";
        public const string EMPTY_QUOTE = "''";
        public const string EMPTY_DATE = "00/00/0000";
        public const string NOT_FOUND = "x";
    }

    public static class Server
    {
        public static string _HOST = "https://portal.grupperalada.com:11443/";
        public static string _PORTALFIX_ORA_URL = "PereladaWS/PereladaOraWS.asmx";
    }

    public static class Language
    {
        public const string Spanish = "es_ES";
        public const string Catalan = "ca_ES";
        public const string Basque = "eu_ES";

        public static class ERP
        {
            public const string Spanish = "CAS";
            public const string Catalan = "CAT";
            public const string Basque = "EUS";
        }
    }

    public static class Culture
    {
        public const string Spanish = "es-ES";
        public const string English = "en-US";
    }

    public static class Delimiters
    {
        public const string Data = ";";
        public const string Token = "|";
        public const string Slash = "/";
        public const string Date = "/";
        public const string Unique = "|-|";
        public const string Description = " - ";
    }

    public static class Days
    {
        public const int WEEK = 7;
        public const int MONTH = 30;
    }
    public static class Currency
    {
        public const string Euro = "€";
        public const string Dollar = "$";
    }
    public static class Divisions
    {
        // Divisions
        public const string NO_DIVISION = "";
        public const string PERELADA_COMERCIAL = "1";
        public const string J_DONANDEU = "9";
        public const string WINE_IS_SOCIAL = "W";
    }
    public static class WIFI
    {
        public static class RSSI
        {
            // Llimit values for RSSI
            public const int EXCELENT = -30;
            public const int VERY_GOOD = -67;
            public const int GOOD = -70;
            public const int POOR = -80;
            public const int BAD = -90;
            public const int NO_CONNECTION = -100;
        }
    }
    public static class Types
    {
        public static class Pickers
        {
            public const int MONTH = 1;
            public const int YEAR = 2;
        }
        public static class Categories
        {
            public const string PROCEDURE = "P";
            public const string INCIDENT = "I";
            public const string WARNING = "W";
            public const string SOLVED = "S";
        }
    }
    public static class Options
    {
        public const int SEND_MAIL = 99;
    }
}
