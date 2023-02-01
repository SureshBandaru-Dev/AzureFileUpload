public class EmployeeService : RepositoryBase<Employee>, IEmployeeService
    {
        public EmployeeService(PostgreSqlContext context) : base(context)
        { }
        public async Task<string> AddEmployeeRecordAsync(Employee employee)
        {
            Create(employee);
            await SaveAsync();
            return employee.id.ToString();
        }

        public async Task<IList<Employee>> GetEmployeeRecordsAsync()
        {
            var res = await FindAllAsync();
            return res.OrderBy(x => x.FirstName).ToList();
        }

        public async Task<Employee?> GetEmployeeSingleRecordAsync(string id)
        {
            var res = await FindByConditionAync(o => o.id.Equals(id));
            return res.FirstOrDefault();
        }
       
        public async Task<bool> UpdateEmployeeRecordAsync(Employee model)
        {
            Update(model);
            int rowsAffected = await Save();
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> DeleteEmployeeRecordAsync(Employee model)
        {
            Delete(model);
            int rowsAffected = await Save();
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }