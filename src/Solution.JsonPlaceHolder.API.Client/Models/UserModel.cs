namespace Solution.JsonPlaceHolder.API.Client.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public Company Company { get; set; }
        public string Website { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public Geo Geo { get; set; }

        public override string ToString()
        {
            return $"{Street} ,{Suite}, {City}, {Zipcode}";
        }
    }

    public class Geo
    {
        public string Lat { get; set; }
        public string Lng { get; set; }

        public override string ToString()
        {
            return $"{Lat}.{Lng}";
        }
    }

    public class Company
    {
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }

        public override string ToString()
        {
            return $"{Name} ,{CatchPhrase}, {Bs}";
        }
    }
}
