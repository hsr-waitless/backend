using Backend.Commands;
using Microsoft.AspNetCore.SignalR.Hubs;
using Moq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Business.Test.Factory
{

    public class MockHubFactory
    {
        public static IHubCallerConnectionContext <dynamic> CreateClients<T>(String responseType, Action <T> action) {
            var mockClients = new Mock<IHubCallerConnectionContext<dynamic>>();
            dynamic caller = new ExpandoObject();
            ((IDictionary<String, object>)caller)[responseType] = action;
            mockClients.Setup(m => m.Caller).Returns((ExpandoObject)caller);

            return mockClients.Object;
        }
    }
}
