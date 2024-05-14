using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vives.Services.Model;

namespace Vives.Services.Extensions
{
    public static class ServiceResultExtensions
    {
        public static void NotEmpty(this ServiceResult serviceResult, string propertyName)
        {
            serviceResult.Messages.Add(new ServiceMessage
            {
                Code = "NotEmpty",
                Message = $"{propertyName} cannot be empty",
                Type = MessageType.Error
            });
        }

        public static void NotDefault(this ServiceResult serviceResult, string propertyName)
        {
            serviceResult.Messages.Add(new ServiceMessage
            {
                Code = "NotDefault",
                Message = $"{propertyName} cannot be the default value",
                Type = MessageType.Error
            });
        }

        public static void NotFound(this ServiceResult serviceResult, string entityName, int id, MessageType type = MessageType.Warning)
        {
            serviceResult.Messages.Add(new ServiceMessage
            {
                Code = "NotFound",
                Message = $"Could not find {entityName} with Id {id}",
                Type = type
            });
        }

        public static void Deleted(this ServiceResult serviceResult, string entityName)
        {
            serviceResult.Messages.Add(new ServiceMessage
            {
                Code = "Deleted",
                Message = $"{entityName} was successfully deleted.",
                Type = MessageType.Info
            });
        }

        public static void LoginFailed(this ServiceResult serviceResult)
        {
            serviceResult.Messages.Add(new ServiceMessage
            {
                Code = "LoginFailed",
                Message = "Login failed. Please check your credentials.",
                Type = MessageType.Error
            });
        }
    }
}
