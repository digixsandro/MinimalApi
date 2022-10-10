namespace Test.Models
{
    public class Word
    {
        public int Id { get; set; }
        public string WordString { get; set; }
        public int Occurence { get; set; }

        public Word(string wordString)
        {
            WordString = wordString;
        }
    }
}
