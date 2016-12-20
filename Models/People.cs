namespace Webextant.Models
{
    public class Person
    {
        public string Key { get; set; }
        public string ObjectID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }
        public string EmailAddress { get; set; }
        public Address Address { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string MobilePhone { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string WebsiteUrl { get; set; }
    }
}