export const formatUsersForSelect = (users) => {
	return users.map((user) => {
		return {
			value: user.id,
			label: `${user.firstName} ${user.lastName}`
		};
	});
};
