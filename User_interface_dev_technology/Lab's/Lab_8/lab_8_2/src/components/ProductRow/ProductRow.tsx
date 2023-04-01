import React from 'react';
import '../ProductRow/ProductRow.css';
import IProductRow from './IProductRow';

const ProductRow = ({product}:IProductRow) =>{
    const name = product.stocked 
    ?product.name 
    : <span style={{color: 'red'}}>
      {product.name}
    </span>;

    return(
        <tr>
        <td>{name}</td>
        <td>{product.price}</td>
      </tr>
    );
};

export default ProductRow;