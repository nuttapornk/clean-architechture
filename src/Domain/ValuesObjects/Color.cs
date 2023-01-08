﻿using Areegator.Agent.Domain.Common;
using Areegator.Agent.Domain.Exceptions;

namespace Areegator.Agent.Domain.ValuesObjects
{
    public class Color : ValueObject
    {
        public static Color White => new("#FFFFFF");

        public static Color Red => new("#FF5733");

        public static Color Orange => new("#FFC300");

        public static Color Yellow => new("#FFFF66");

        public static Color Green => new("#CCFF99");

        public static Color Blue => new("#6666FF");

        public static Color Purple => new("#9966CC");

        public static Color Grey => new("#999999");

        public string Code { get; private set; } = "#000000";

        static Color()
        {

        }

        private Color()
        {

        }

        private Color(string code)
        {
            Code = code;
        }

        public static Color From(string code)
        {
            var colour = new Color { Code = code };

            if (!SupportedColours.Contains(colour))
            {
                throw new UnsupportedColorException(code);
            }

            return colour;
        }

        public static implicit operator string(Color colour)
        {
            return colour.ToString();
        }

        public static explicit operator Color(string code)
        {
            return From(code);
        }

        public override string ToString()
        {
            return Code;
        }

        protected static IEnumerable<Color> SupportedColours
        {
            get
            {
                yield return White;
                yield return Red;
                yield return Orange;
                yield return Yellow;
                yield return Green;
                yield return Blue;
                yield return Purple;
                yield return Grey;
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Code;
        }
    }
}
