namespace Game.Models
{
    public class IdProvider
    {
        private int id;

        public int Get() => ++id;
    }
}
