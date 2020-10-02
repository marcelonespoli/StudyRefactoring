using Example1_Refactoring.Models;
using System.Collections.Generic;

namespace Example1_Refactoring.Data
{
    public class RequestData
    {
        public static List<Play> GetPlays()
        {
            return new List<Play>
            {
                new Play
                {
                    Id = "hamlet",
                    Details = new PlayDetails
                    {
                        Name = "Hamlet",
                        Type = "tragedy"
                    }
                },
                new Play
                {
                    Id = "as-like",
                    Details = new PlayDetails
                    {
                        Name = "As You Like It",
                        Type = "comedy"
                    }
                },
                new Play
                {
                    Id = "othello",
                    Details = new PlayDetails
                    {
                        Name = "Othello",
                        Type = "tragedy"
                    }
                }
            };
        }

        public static Invoice GetInvoice()
        {
            return new Invoice
            {
                Customer = "BigCo",
                Performances = new List<Performance>
                    {
                        new Performance
                        {
                            PlayId = "hamlet",
                            Audience = 55
                        },
                        new Performance
                        {
                            PlayId = "as-like",
                            Audience = 35
                        },
                        new Performance
                        {
                            PlayId = "othello",
                            Audience = 40
                        }
                    }
            };
        }
    }
}
