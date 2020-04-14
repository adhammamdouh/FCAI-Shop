namespace FCAI_Shop._Utilities {
    public static class Roles
    {
        public const string Admin = "Admin";
        public const string User = "User";

        public static string AddRole(string currentRoles, string newRole)
        {
            if (string.IsNullOrWhiteSpace(currentRoles))
                return newRole;

            return currentRoles + ", " + newRole;
        }
    }
}
