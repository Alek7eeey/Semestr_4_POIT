import React from 'react';
import SearchBar from '../SearchBar/SearchBar';
import ProductTable from '../ProductTable/ProductTable.js';
import style from '../FilterableProductTable/FilterableProductTable.css';

const FilterableProductTable = ({products}) =>
{
    const [filterText, setFilterText] = React.useState('');
    const [inStockOnly, setInStockOnly] = React.useState(false);
  
    const handleFilterTextChange = (filterText) => setFilterText(filterText);
  
    const handleInStockChange = (inStockOnly) => setInStockOnly(inStockOnly);
  
    return (
      <div class="mainDiv" style={style}>
        <SearchBar
          filterText={filterText}
          inStockOnly={inStockOnly}
          onFilterTextChange={handleFilterTextChange}
          onInStockChange={handleInStockChange}
        />
        <div class="wrapTable">
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