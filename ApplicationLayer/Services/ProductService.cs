using ApplicationLayer.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;

namespace ApplicationLayer.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var products = await _unitOfWork.Products.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }

    public async Task<ProductDto> GetByIdAsync(int id)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(id);
        return _mapper.Map<ProductDto>(product);
    }

    public async Task AddAsync(ProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        await _unitOfWork.Products.AddAsync(product);
        await _unitOfWork.CommitAsync();
    }

    public async Task UpdateAsync(ProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        _unitOfWork.Products.UpdateAsync(product);
        await _unitOfWork.CommitAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Products.DeleteAsync(id);
        await _unitOfWork.CommitAsync();
    }
}
