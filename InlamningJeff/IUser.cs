namespace InlamningJeff
{
    public interface IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }
    }
}