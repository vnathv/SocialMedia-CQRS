using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.Core.Domain;
using Post.Common.Events;

namespace Post.Cmd.Domain.Aggregates
{
    public class PostAggregate : AggregateRoot
    {
        public PostAggregate()
        {

        }

        public PostAggregate(Guid id, string author, string message)
        {
            RaiseEvent(new PostCreatedEvent
            {
                Id = id,
                Author = author,
                Message = message,
                DatePosted = DateTime.Now
            });
        }
        public bool Active { get; set; }
        public string Author { get; set; }

        private readonly Dictionary<Guid, Tuple<string, string>> _comments = new();


        public void Apply(PostCreatedEvent @event)
        {
            Id = @event.Id;
            Active = true;
            Author = @event.Author; 
        }


        public void EditMessage(string message)
        {
            if(!Active)
            {
                throw new InvalidOperationException("You cannot edit the message if an inactive post!");
            }

            if(string.IsNullOrWhiteSpace(message))
        }
    }
}