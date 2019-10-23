using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDeAlimentos.Constants
{
    public static class ControllerActionDescriptions
    {
        public static class UserControllerActions
        {
            public const string ResetPassword = "Solicitar reset de contraseña";
            public const string RegisterNewUser = "Crear nuevo usuario";
            public const string Update = "Modificar usuario";
            public const string UpdateUsersStatusByKeys = "Cambiar estado de usuarios";
            public const string CheckEmail = "Enviar mail de verificación";
        }

        public static class InternalUserControllerActions
        {
            public const string Create = "Crear usuario de back office";
            public const string Update = "Modificar usuario de back office";
            public const string Delete = "Eliminar usuario de back office";
        }

        public static class EmailTemplateControllerActions
        {
            public const string Create = "Crear nueva plantilla de email";
            public const string Update = "Modificar plantilla de email";
        }

        public static class ApplicationControllerActions
        {
            public const string Update = "Modificar proveedor de acceso";
        }

        public static class DynamicFieldControllerActions
        {
            public const string Create = "Crear campo dínamico";
            public const string Update = "Modificar campo dínamico";
        }

        public static class RoleControllerActions
        {
            public const string Update = "Modificar Roles";
        }

        public static class CredentialControllerActions
        {
            public const string Create = "Crear una credencial";
            public const string Enable = "Hablilitar credencial";
            public const string Disable = "Deshablilitar credencial";
        }
    }
}
