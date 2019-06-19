using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;

namespace SorteioDevCamp.gRPC.Services
{
    public class RegisterService : Register.RegisterBase
    {
        public override Task<RegisterReply> Store(RegisterRequest request, ServerCallContext context)
        {
            return Task.FromResult(new RegisterReply
            {
                Message = "OK"
            });
        }
    }
}
