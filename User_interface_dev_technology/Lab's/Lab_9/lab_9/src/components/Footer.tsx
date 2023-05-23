import React from 'react';
import { Filter } from '../action/actions';
import FilterLink from '../containers/FilterLink';

const Footer = () => (
  <div>
    <span>Show: </span>
    <FilterLink filter={Filter.SHOW_ALL}>
      All
    </FilterLink>
    <FilterLink filter={Filter.SHOW_ACTIVE}>
      Active
    </FilterLink>
    <FilterLink filter={Filter.SHOW_COMPLETED}>
      Completed
    </FilterLink>
  </div>
);

export default Footer;