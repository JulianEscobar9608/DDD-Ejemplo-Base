namespace VirtualEducation.DDD.Domain.Teacher.ValueObjects.Account
{
    public record Permissions
    {
        //variables
        public string role { get; init; }
        //constructor
        internal Permissions(string role)
        {
            this.role = role;
        }
        //create method
        public static Permissions Create(string role)
        {
            Validate(role);
            return new Permissions(role);
        }
        //validate method
        public static void Validate(string role)
        {
            if (role.Equals(null))
            {
                throw new ArgumentNullException("Role cannot be null");
            }
        }
    }
}
