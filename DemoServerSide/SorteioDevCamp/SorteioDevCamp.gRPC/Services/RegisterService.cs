using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Configuration;
using RegisterProto;
using Dapper;

namespace SorteioDevCamp.gRPC.Services
{
    public class RegisterService : Register.RegisterBase
    {
        private string _connectionString;

        public RegisterService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        public override Task<RegisterReply> Store(RegisterRequest request, ServerCallContext context)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var exists = connection.ExecuteScalar<bool>("select count(1) from Participants where Email = @email", new { email = request.Email });

                    if (exists)
                    {
                        return Task.FromResult(new RegisterReply
                        {
                            Message = "Este email já encontra-se cadastrado no sistema."
                        });
                    }

                    var sql = "insert into Participants (Name, Email, Company, Role) values (@Name, @Email, @Company, @Role)";

                    var records = connection.Execute(sql, request);

                    return Task.FromResult(new RegisterReply
                    {
                        Message = records > 0 ? "Cadastro realizado. Boa sorte!" : "Falha no cadastro."
                    });
                }
            }
            catch (Exception ex)
            {
                return Task.FromResult(new RegisterReply { Message = ex.Message });
            }         
        }
    }
}
