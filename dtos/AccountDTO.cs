namespace estudoRepository.dtos
{
    public class AccountDTO
    {
        public int Id { get; set; }

        public int userId { get; set; }

        public double balance { get; set; }

        public bool canNegativeBalance { get; set; }
    }
}