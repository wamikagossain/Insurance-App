using Dapper;
using LearnDapper.Data;
using LearnDapper.Model;

namespace LearnDapper.Repo
{
    public class PoliciesRepo : IPoliciesRepo
    {
        private readonly DapperDBContext context;

        public PoliciesRepo(DapperDBContext context)
        {
            this.context = context;
        }

        public async Task<string> Create(policies policies)
        {
            string response = string.Empty;
            string query = "Insert into Policies(policy_type, PolicyOwnerID, PolicyStartDate, PolicyEndDate, PolicyPremium, PolicyFrequency) values (@policy_type, @PolicyOwnerID, @PolicyStartDate, @PolicyEndDate, @PolicyPremium, @PolicyFrequency)";
            var parameters = new DynamicParameters();
            //parameters.Add("policyID", policies.policyID, System.Data.DbType.Int32);
            parameters.Add("policy_type", policies.policyType, System.Data.DbType.String);
            parameters.Add("PolicyOwnerID", policies.PolicyOwnerID, System.Data.DbType.Int32);
            parameters.Add("PolicyStartDate", policies.policyStartDate, System.Data.DbType.Date);
            parameters.Add("PolicyEndDate", policies.policyEndDate, System.Data.DbType.Date);
            parameters.Add("PolicyPremium", policies.policyPremium, System.Data.DbType.Decimal);
            parameters.Add("PolicyFrequency", policies.policyFrequency, System.Data.DbType.String);

            using (var connection = this.context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
                response = "pass";

                return response;
            }
        }

        public async Task<List<policies>> GetAll()
        {
            string query = "Select * From Policies";
            using (var connection = this.context.CreateConnection())
            {
                var policieslist = await connection.QueryAsync<policies>(query);
                return policieslist.ToList();
            }
        }

        public async Task<policies> Getbycode(int policyID)
        {
            string query = "Select * From Policies where policyID=@policyID";
            using (var connection = this.context.CreateConnection())
            {
                var policieslist = await connection.QueryFirstOrDefaultAsync<policies>(query, new { policyID });
                return policieslist;
            }
        }

        public async Task<string> Remove(int policyID)
        {
            string response = string.Empty;
            string query = $"Delete From Policies where policyID={policyID}";
            using (var connection = this.context.CreateConnection())
            {
                var policieslist = await connection.ExecuteAsync(query);
                response = "pass";

                return response;
            }
        }

        public async Task<string> Update(policies policies, int policyID)
        {
            string response = string.Empty;
            string query = "update Policies set policy_type=@policy_type, PolicyOwnerID=@PolicyOwnerID, PolicyStartDate=@PolicyStartDate, PolicyEndDate=@PolicyEndDate, PolicyPremium=@PolicyPremium, PolicyFrequency=@PolicyFrequency where policyID=@policyID";
            var parameters = new DynamicParameters();
            parameters.Add("policyID", policyID, System.Data.DbType.Int32);
            //parameters.add("policyid", policies.policyid, system.data.dbtype.int32);
            parameters.Add("policy_type", policies.policyType, System.Data.DbType.String);
            parameters.Add("PolicyOwnerID", policies.PolicyOwnerID, System.Data.DbType.Int32);
            parameters.Add("PolicyStartDate", policies.policyStartDate, System.Data.DbType.Date);
            parameters.Add("PolicyEndDate", policies.policyEndDate, System.Data.DbType.Date);
            parameters.Add("PolicyPremium", policies.policyPremium, System.Data.DbType.Decimal);
            parameters.Add("PolicyFrequency", policies.policyFrequency, System.Data.DbType.String);

            using (var connection = this.context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
                response = "pass";

                return response;
            }
        }
    }
}
