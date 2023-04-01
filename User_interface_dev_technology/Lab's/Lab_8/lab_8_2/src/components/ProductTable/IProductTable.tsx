import IState from "../../IState";

export default interface IProductTable{
    products: IState[];
    filterText: string;
    inStockOnly: boolean;
}