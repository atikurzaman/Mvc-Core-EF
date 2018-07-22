﻿using Application.Data.Repository;
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

        private IAttributeRepository _productAttribute;
        public IAttributeRepository Attributes
        {
            get
            {
                if (_productAttribute == null)
                {
                    _productAttribute = new AttributeRepository(context);
                }
                return _productAttribute;
            }
        }

        private IAttributeValueRepository _productAttributeItem;
        public IAttributeValueRepository AttributeValues
        {
            get
            {
                if (_productAttributeItem == null)
                {
                    _productAttributeItem = new AttributeValueRepository(context);
                }
                return _productAttributeItem;
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
