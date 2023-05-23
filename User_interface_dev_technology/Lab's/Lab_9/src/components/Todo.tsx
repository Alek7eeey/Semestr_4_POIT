import React from 'react';
import PropTypes from 'prop-types';

type PTodo = {
    onClick: any;
    completed: boolean;
    text: string;
}

const Todo = ({ onClick, completed, text } : PTodo) => (
  <li
    onClick={onClick}
    style={{
      textDecoration: completed ? 'line-through' : 'none',
    }}
  >
    {text}
  </li>
);

export default Todo;