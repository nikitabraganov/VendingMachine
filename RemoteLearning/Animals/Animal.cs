namespace Animals
{
    public abstract class Animal
    {
        public string Name { get; protected set; }

        public string Sound { get; protected set; }

        public string GeneralInfo()
        {
            return $"{Name} makes {Sound}";
        }
    }
}
