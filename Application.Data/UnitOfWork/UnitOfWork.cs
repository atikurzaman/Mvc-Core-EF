using Application.Data.Repository;
using System;
using System.Threading.Tasks;


namespace Application.Data.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }        

        private ICategoryRepository _categories;
        public ICategoryRepository Categories
        {
            get
            {
                if (_categories == null)
                {
                    _categories = new CategoryRepository(context);
                }
                return _categories;
            }
        }

        private IMenuRepository _menus;
        public IMenuRepository Menus
        {
            get
            {
                if (_menus == null)
                {
                    _menus = new MenuRepository(context);
                }
                return _menus;
            }
        }

        private IBrandRepository _brands;
        public IBrandRepository Brands
        {
            get
            {
                if (_brands == null)
                {
                    _brands = new BrandRepository(context);
                }
                return _brands;
            }
        }

        private IAttributeRepository _attribute;
        public IAttributeRepository Attributes
        {
            get
            {
                if (_attribute == null)
                {
                    _attribute = new AttributeRepository(context);
                }
                return _attribute;
            }
        }

        private IAttributeValueRepository _AttributeValue;
        public IAttributeValueRepository AttributeValues
        {
            get
            {
                if (_AttributeValue == null)
                {
                    _AttributeValue = new AttributeValueRepository(context);
                }
                return _AttributeValue;
            }
        }

        private ITagRepository _tag;
        public ITagRepository Tags
        {
            get
            {
                if (_tag == null)
                {
                    _tag = new TagRepository(context);
                }
                return _tag;
            }
        }

        public int Complete()
        {
            int result = 0;
            try
            {
                result = context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            return result;
        }
        public async Task<int> CompleteAsync()
        {
            int result = 0;
            try
            {
                result = await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            return result;
        }
        public void Dispose()
        {
            context.Dispose();
        }        
    }
}
