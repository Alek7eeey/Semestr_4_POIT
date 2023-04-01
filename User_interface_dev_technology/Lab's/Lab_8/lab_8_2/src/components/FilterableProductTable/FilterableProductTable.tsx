import React from 'react';
import SearchBar from '../SearchBar/SearchBar';
import ProductTable from '../ProductTable/ProductTable';
import './FilterableProductTable.module.css';
import style from './FilterableProductTable.module.css';
import IFilterable from './IFilterableInterface';

const FilterableProductTable = ({products}:IFilterable) =>
{
    const [filterText, setFilterText] = React.useState<string>('');
    const [inStockOnly, setInStockOnly] = React.useState<boolean>(false);
  
    const handleFilterTextChange = (filterText:string) => setFilterText(filterText);
  
    const handleInStockChange = (inStockOnly:boolean) => setInStockOnly(inStockOnly);
  
    return (
      <div className="mainDiv" style={style}>
        <SearchBar
          filterText={filterText}
          inStockOnly={inStockOnly}
          onFilterTextChange={handleFilterTextChange}
          onInStockChange={handleInStockChange}
        />
        <div className="wrapTable">
        <ProductTable
          products={products}
          filterText={filterText}
          inStockOnly={inStockOnly}
        />
        </div>
      </div>
    );
}

export default FilterableProductTable;