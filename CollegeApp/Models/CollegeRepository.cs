namespace CollegeApp.Models
{
    public static  class CollegeRepository
    {
        public static List<Students> Students { get; set; }= new List<Students>{
                new Students
            {
            Id = 1,
                Studentname = "Yukta ",
                Email = "Yukta@gmail.com",
                Address = "Jaipur"

            },
            new Students
            {
                    Id = 2,
                Studentname = "Neha ",
                Email = "Neha@gmail.com",
                Address = "Mumbai"


            }

            };
    }
}
