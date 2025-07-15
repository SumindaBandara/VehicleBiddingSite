import React from 'react';

const SvgIcon = ({ iconPath }) => {
  return (
    <svg>
      <use xlinkHref={`#${iconPath}`} />
    </svg>
  );
};

export default SvgIcon;