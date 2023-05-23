import { connect } from 'react-redux';
import Link from '../components/Link';
import { IVisibilityFilterAction, setVisibilityFilter } from '../action/actions';

const mapStateToProps = (state : any, ownProps : IVisibilityFilterAction) => ({
  active: ownProps.filter === state.visibilityFilter,
});

const mapDispatchToProps = (dispatch : any, ownProps : IVisibilityFilterAction) => ({
  onClick: () =>
    dispatch(setVisibilityFilter(ownProps.filter)),
});

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(Link);