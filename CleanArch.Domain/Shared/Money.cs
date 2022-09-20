﻿using CleanArch.Domain.Shared.Exceptions;


namespace CleanArch.Domain.Shared
{
    public class Money
    {
        /// <summary>
        /// Rial
        /// </summary>
        public int Value { get; }

        public Money(int rialValue)
        {
            if (rialValue < 0)
                throw new InvalidDomainDataException();

            Value = rialValue;
        }

        public static Money FromRial(int value)
        {
            return new Money(value);
        }
        public static Money FromTooman(int value)
        {
            return new Money(value * 10);
        }

        public static Money operator +(Money firstMoney, Money Money2)
        {
            return new Money(firstMoney.Value + Money2.Value);
        }

        public static Money operator -(Money firstMoney, Money Money2)
        {
            return new Money(firstMoney.Value - Money2.Value);
        }

        public override string ToString()
        {
            return Value.ToString("#,0");
        }
    }
}
