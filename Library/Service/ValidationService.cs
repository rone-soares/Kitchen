using Library.Exceptions;
using Library.Resources;
using System;

namespace Library.Service
{
    public static class ValidationService
    {
        public static string SetDescription(string description, string field, int sizeMin, int sizeMax)
        {
            if ((string.IsNullOrEmpty(description) && sizeMin > 0) || description.Length < sizeMin)
                throw new Exception(string.Format(MessageResource.MustBeAMinimumOfCharactersIn, sizeMin.ToString(), field.ToLower()));

            if (!string.IsNullOrEmpty(description) && description.Length > sizeMax)
                throw new Exception(string.Format(MessageResource.MustBeAMaximumOfCharactersIn, sizeMax.ToString(), field.ToLower()));            

            return description;
        }        

        public static void SetPeriodOfValue(decimal start, decimal end, string startField, string endField)
        {
            if (start > end)
                throw new Exception(string.Format(MessageResource.TheStartValueCannotBeGreaterThanTheEndValue, startField.ToLower(), endField.ToLower()));
        }

        public static decimal SetValue(decimal value, string field, decimal valueMin, decimal valueMax)
        {
            if (value < valueMin)
                throw new Exception(string.Format(MessageResource.MustBeAMinimumOfValueIn, valueMin.ToString(), field.ToLower()));

            if (value > valueMax)
                throw new Exception(string.Format(MessageResource.MustBeAMaximumOfValueIn, valueMax.ToString(), field.ToLower()));

            return value;
        }

        public static int SetValue(int value, string field, int valueMin, int valueMax)
        {
            if (value < valueMin)
                throw new Exception(string.Format(MessageResource.MustBeAMinimumOfValueIn, valueMin.ToString(), field.ToLower()));

            if (value > valueMax)
                throw new Exception(string.Format(MessageResource.MustBeAMaximumOfValueIn, valueMax.ToString(), field.ToLower()));

            return value;
        }

        public static void SetPeriodOfDate(DateTime start, DateTime end, string startField, string endField)
        {
            SetDate(start, startField);
            SetDate(end, endField);
            
            if (start > end)
                throw new Exception(string.Format(MessageResource.TheStartDateCannotBeGreaterThanTheEndDate, startField.ToLower(), endField.ToLower()));
        }

        public static DateTime SetDate(DateTime date, string field)
        {
            if (date == DateTime.MinValue)
                throw new Exception(string.Format(MessageResource.MustBeADateIn, field.ToLower()));

            return date;
        }

        public static void ValidateParameterId(int id, string field)
        {
            if (id <= 0)
                throw new InvalidParameterException(string.Format(MessageResource.MustBeAValidIdOfThe, field.ToLower()));
        }

        public static void ValidateExistRequest(dynamic request, string field)
        {
            if ((request == null))
                throw new InvalidParameterException(string.Format(MessageResource.MustBeTheParametersToInsertNew, field.ToLower()));
        }

        public static void ValidateParameterString(string param, string field)
        {
            if (string.IsNullOrEmpty(param))
                throw new InvalidParameterException(string.Format(MessageResource.MustBeAValid, field.ToLower()));
        }
    }
}
