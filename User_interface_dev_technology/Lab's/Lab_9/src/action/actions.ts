let nextTodoId = 0;

export interface IAction {
    type?: string;
}

export interface IAddAction extends IAction {
    id: number;
    text: string;
}

export interface IVisibilityFilterAction extends IAction {
    filter: Filter;
}

export interface IToggleTodoAction extends IAction {
    id: number;
}

export enum Filter {
    SHOW_ALL,
    SHOW_COMPLETED,
    SHOW_ACTIVE
}

export const addTodo = (text : string) => ({
  type: 'ADD_TODO',
  id: nextTodoId++,
  text,
} as IAddAction);

export const setVisibilityFilter = (filter : Filter) => ({
  type: 'SET_VISIBILITY_FILTER',
  filter,
} as IVisibilityFilterAction);

export const toggleTodo = (id : number) => ({
  type: 'TOGGLE_TODO',
  id,
} as IToggleTodoAction);
