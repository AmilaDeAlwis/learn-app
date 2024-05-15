﻿namespace backend.Models
{
    public class AnswerOption
    {
        public string Id { get; set; } // Unique identifier for the answer option document
        public string OptionText { get; set; }

        // Reference to the CustomQuestion ID
        public string CustomQuestionId { get; set; }

    }
}
