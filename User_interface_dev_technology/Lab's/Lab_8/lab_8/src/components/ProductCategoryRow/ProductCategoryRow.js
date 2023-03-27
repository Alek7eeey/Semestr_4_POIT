import React from 'react';
import style from '../ProductCategoryRow/ProductCategoryRow.css';
const ProductCategoryRow = ({ category }) => (
    <tr style={style}>
      <th colSpan="2">
        {category}
      </th>
    </tr>
  );

  export default ProductCategoryRow;