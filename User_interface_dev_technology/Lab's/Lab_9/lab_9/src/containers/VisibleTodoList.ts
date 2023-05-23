import { toggleTodo } from './../action/actions';
import { connect } from 'react-redux';
import TodoList, { ITodo } from '../components/TodoList';
import { Filter } from '../action/actions';

const getVisibleTodos = (todos : ITodo[], filter : Filter) => {
  switch (filter) {
    case Filter.SHOW_ALL:
      return todos;
    case Filter.SHOW_COMPLETED:
      return todos.filter((t) => t.completed);
    case Filter.SHOW_ACTIVE:
      return todos.filter((t) => !t.completed);
    default:
      throw new Error('Unknown filter: ' + filter);
  }
};

const mapStateToProps = (state : any) => ({
  todos: getVisibleTodos(
    state.todos,
    state.visibilityFilter
  ),
});

const mapDispatchToProps = (dispatch : any) => ({
  toggleTodo: (id : number) => dispatch(toggleTodo(id)),
});

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(TodoList);