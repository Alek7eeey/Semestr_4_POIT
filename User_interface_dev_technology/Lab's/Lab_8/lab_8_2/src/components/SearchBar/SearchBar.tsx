import React from 'react';
import '../SearchBar/SearchBar.css';
import ISearch from './ISearch';

const SearchBar = ({ filterText, inStockOnly, onFilterTextChange, onInStockChange }:ISearch) => {
return(
    <form>
    <input
      type="text"
      placeholder="Search..."
      value={filterText}
      onChange={(e) => onFilterTextChange(e.target.value)}
    />
    <p>
      <input
        type="checkbox"
        checked={inStockOnly}
        onChange={(e) => onInStockChange(e.target.checked)}
        className="custom-checkbox" id="happy" name="happy" value="yes"
      />
      {' '}
      Only show products in stock
    </p>
  </form>
);
};

export default SearchBar;