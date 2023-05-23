import React from 'react';
import { connect } from 'react-redux';
import { addTodo } from '../action/actions';

const AddTodo = ({ dispatch } : { dispatch : any }) => {
  let input : HTMLInputElement | null;
  return (
    <div>
      <form onSubmit={(e) => {
        e.preventDefault();
        if (!input?.value.trim()) {
          return;
        }
        dispatch(addTodo(input?.value));

        if(input !== null)
          input.value = '';
      }}>
        <input ref={(node) => (input = node)} />
        <button type="submit">Add Todo</button>
      </form>
    </div>
    )
};

export default connect()(AddTodo);