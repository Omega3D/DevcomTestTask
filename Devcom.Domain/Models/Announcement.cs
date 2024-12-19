using Devcom.Domain.Enums;

namespace Devcom.Domain.Entities
{
    public class Announcement
    {
        public const int MAX_TITLE_LENGTH = 200;

        private Announcement(int id, string title, string description, DateTime createdDate, Status status, string category, string subCategory)
        {
            Id = id;
            Title = title;
            Description = description;
            CreatedDate = createdDate;
            Status = status;
            Category = category;
            SubCategory = subCategory;
        }

        public int Id { get; }
        public string Title { get; }
        public string Description { get; }
        public DateTime CreatedDate { get; }
        public Status Status { get; }
        public string Category { get; }
        public string SubCategory { get; }

        public static (Announcement Announcement, string Error) Create(
            int id,
            string title,
            string description,
            DateTime createdDate,
            Status status,
            string category,
            string subCategory)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
            {
                error = $"Title cannot be empty or longer than {MAX_TITLE_LENGTH} characters.";
            }

            if (string.IsNullOrEmpty(category))
            {
                error = "Category cannot be empty.";
            }

            if (string.IsNullOrEmpty(subCategory))
            {
                error = "SubCategory cannot be empty.";
            }

            var announcement = new Announcement(id, title, description, createdDate, status, category, subCategory);

            return (announcement, error);
        }
    }
}
