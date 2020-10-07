using AnimalShelter.Core.Services.Models;
using AnimalShelter.Core.Enums;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Text;
using AnimalShelter.Core.Services.Utility;

namespace AnimalShelter.Infrastructure.Common.Utility
{
    public class CrudResult<T> : ICrudResult
        where T : class, IDbModel
    {
        public bool IsSucceeded { get; }
        public string Message { get; set; }
        public object Result { get; set; }

        public CrudResult(DbOperation operation, bool isSucceeded, bool isMany, string message = null, object result = null)
        {
            IsSucceeded = isSucceeded;
            Message = message ?? BuildDefaultResultMessage(operation, isSucceeded, isMany);
            Result = result;
        }

        private string BuildDefaultResultMessage(DbOperation operation, bool isSucceeded, bool isMany)
        {
            var msg = $"Request {(isSucceeded ? "is succesful" : "failed")}";

            if (operation.Equals(DbOperation.Create) || operation.Equals(DbOperation.Update) || operation.Equals(DbOperation.Delete))
            {
                var method = operation.ToString();
                var displayOperation = $"{(method.EndsWith('e') ? $"{method}d" : $"{method}ed")}";

                var itemName = isMany ? typeof(T).Name.Pluralize() : typeof(T).Name;
                var msgPart = $"{itemName} {(IsSucceeded ? (isMany ? "s are" : "is") : "could")}";

                msg = $"{msgPart} {(IsSucceeded ? "succesfully" : "not")}{(IsSucceeded ? string.Empty : " be")} {displayOperation}{(IsSucceeded ? "!" : string.Empty)}";
            }

            return msg;
        }
    }
}
