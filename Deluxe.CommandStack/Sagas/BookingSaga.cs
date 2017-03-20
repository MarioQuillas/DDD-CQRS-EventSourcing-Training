﻿using Deluxe.CommandStack.Commands;
using Deluxe.CommandStack.Events;

namespace Deluxe.CommandStack.Sagas
{
    public class BookingSaga : Saga,
            IStartWithMessage<RequestBookingCommand>
    {
        private readonly IRepository _repository;

        public BookingSaga(IBus bus, IEventStore eventStore)
            : base(bus, eventStore)
        {
            _repository = new BookingRepository();
        }

        public BookingSaga(IBus bus, IEventStore eventStore, IRepository repository)
            : base(bus, eventStore)
        {
            _repository = repository;
        }

        public void Handle(RequestBookingCommand message)
        {
            var request = BookingRequest.Factory.Create(message.CourtId, message.Hour, message.Length, message.UserName);
            var response = _repository.CreateBookingFromRequest(request);
            if (!response.Success)
            {
                var rejected = new BookingRequestRejectedEvent(request.Id, response.Description);
                Bus.RaiseEvent(rejected);
                return;
            }

            var created = new BookingCreatedEvent(request.Id, response.AggregateId);
            Bus.RaiseEvent(created);
        }
    }
}