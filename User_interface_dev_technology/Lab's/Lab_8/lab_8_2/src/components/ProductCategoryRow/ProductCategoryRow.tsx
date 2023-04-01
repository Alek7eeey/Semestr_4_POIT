import React from 'react';
import style from '../ProductCategoryRow/ProductCategoryRow.module.css';
import IProductCategory from './IProductCategory';

const ProductCategoryRow = ({ category }: IProductCategory) => (
    <tr style={style}>
      <th colSpan={2}>
        {category}
      </th>
    </tr>
  );

  export default ProductCategoryRow;