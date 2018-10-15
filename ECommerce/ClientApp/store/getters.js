export const shoppingCartTotal = state => {
  const reducer = (accumulator, cartItem) =>
    accumulator + cartItem.price * cartItem.quantity;

  return state.cart.reduce(reducer, 0);
};

export const isAuthenticated = state => {
  return (
    state.auth !== null &&
    state.auth.access_token !== null &&
    newDate(state.auth.access_token_expiration) > newDate()
  );
};
