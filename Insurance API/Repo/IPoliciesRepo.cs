using LearnDapper.Model;

namespace LearnDapper.Repo
{
    public interface IPoliciesRepo
    {
        Task<List<policies>> GetAll();
        Task<policies> Getbycode(int policyID);

        Task<string> Create(policies policies);

        Task<string> Update(policies policies, int policyID);

        Task<string> Remove(int policyID);
    }
}
