import { IAction, IAddAction, IToggleTodoAction } from "../action/actions";
import { ITodo } from "../components/TodoList";

const todos = (state : ITodo[] = [], action : IAction) => {
    switch (action.type) {
      case 'ADD_TODO':
        const aaction = action as IAddAction;
        return [
          ...state,
          {
            id: aaction.id,
            text: aaction.text,
            completed: false,
          },
        ];
      case 'TOGGLE_TODO':
        const taction = action as IToggleTodoAction;
        return state.map((todo) =>
          todo.id === taction.id
            ? { ...todo, completed: !todo.completed }
            : todo
        );
      default:
        return state;
    }
  };
  
  export default todos;