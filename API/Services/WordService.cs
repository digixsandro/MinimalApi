using Microsoft.EntityFrameworkCore;
using Test.Db;
using Test.Models;

namespace Test.Services
{
    public class WordService
    {
        private readonly PartDb _db;

        public WordService(PartDb db)
        {
            _db = db;
        }

        public void LogNewWords(string description)
        {
            var words = description.Trim().Split(" ");
            AddWords(words);
        }

        public void UpdateWords(string oldDescription, string descriptionUpdated)
        {
            var words = descriptionUpdated.Trim().Split(" ");
            
            AddWords(words);
            RemoveWords(oldDescription);
        }

        private void AddWords(string[] words)
        {
            foreach (var word in words)
            {
                var partWord = _db.Words.FirstOrDefault(w => w.WordString == word);
                if (partWord is null)
                {
                    var newWord = new Word(word);
                    _db.Words.AddAsync(newWord);
                }
                else
                {
                    partWord.Occurence += 1;
                }

                _db.SaveChangesAsync();
            }
        }

        public async void RemoveWords(string oldDescription)
        {
            var wordsToRemove = oldDescription.Trim().Split(" ");

            foreach (var wordToRemove in wordsToRemove)
            {
                var word= _db.Words.FirstOrDefault(w => w.WordString == wordToRemove);
                
                word.Occurence -= 1;

                _db.SaveChangesAsync();
            }
        }
    }
}
