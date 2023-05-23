import React from 'react';

type PLink = {
    active: boolean;
    children?: any;
    onClick?: () => void
} 

const Link = ({ active, children, onClick } : PLink) => (
  <button
    onClick={onClick}
    disabled={active}
    style={{
      marginLeft: '4px',
    }}
  >
    {children}
  </button>
);

export default Link;