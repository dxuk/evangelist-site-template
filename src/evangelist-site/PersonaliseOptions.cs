namespace evangelist_site
{
    public class PersonaliseOptions
    {
        public string Webroot { get; set; }
        public string BlogFeed { get; set; }
        public string BlogUrl { get; set; }
        public string Title { get; set; }

        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string FirstName { get; set; }

        public string ShortDescription { get; set; }
        public string Technologies { get; set; }
        public string Location { get; set; }
        public string Twitter { get; set; }

        public string TwitterHome { get; set; }
        public string LinkedInHome { get; set; }
        public string SkypeHome { get; set; }
        public string GithubHome { get; set; }
        public string StackOverflowHome { get; set; }
        public string EmailAddress { get; set; }
        public Bio Bio { get; set; }
    }
    public class Bio
    {
        public string FirstPerson { get; set; }
        public string ThirdPerson { get; set; }
        public string Short { get; set; }
    }
}
