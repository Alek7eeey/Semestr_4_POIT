import React from 'react';
import PropTypes from 'prop-types';
import Todo from './Todo';
import { IToggleTodoAction } from '../action/actions';

export interface ITodo {
    id: number;
    completed: boolean;
    text: string;
}

type PTodoList = {
    todos : ITodo[];
    toggleTodo: (id : number) => void;
}

const TodoList = ({ todos, toggleTodo } : PTodoList) => (
  <ul>
    {todos.map((todo) => (
      <Todo
        key={todo.id}
        {...todo}
        onClick={() => toggleTodo(todo.id)}
      />
    ))}
  </ul>
);

export default TodoList;